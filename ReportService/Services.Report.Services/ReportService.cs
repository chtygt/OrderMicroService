using System.Net;
using Microsoft.EntityFrameworkCore;
using Services.Order.Client;
using Services.Customer.Client;
using Services.Product.Client;
using Services.Report.Model;
using Services.Report.Repositories.Interfaces;
using Services.Report.Services.Events;
using Services.Shared.Authentication.Helper;
using Services.Shared.EventBus;
using Services.Shared.Models;
using Services.Report.Services.RequestModel;

namespace Services.Report.Services
{
    public class ReportService
    {
        private readonly IOrderLocationReportRepository _orderLocationReportRepository;
        private readonly ReportEvents _reportEvents;
        private readonly HttpContextHelper _httpContextHelper;
        private readonly OrderClient _orderClient;
        private readonly CustomerClient _customerClient;
        private readonly ProductClient _productClient;
        public ReportService(IOrderLocationReportRepository orderLocationReportRepository,
            ReportEvents reportEvents, HttpContextHelper httpContextHelper, OrderClient orderClient, CustomerClient customerClient, ProductClient productClient)
        {
            _orderLocationReportRepository = orderLocationReportRepository;
            _reportEvents = reportEvents;
            _httpContextHelper = httpContextHelper;
            _orderClient = orderClient;
            _customerClient = customerClient;
            _productClient = productClient;
        }


        public ApiResult ReportRequest(ReportRequest paramModel)
        {
            try
            {
                var locationReport = new OrderStatusReport()
                {
                    RequestDate = DateTime.UtcNow,
                    ReportStatus = ReportStatus.Preparing,
                    StartDate=paramModel.StartDate,
                    EndDate=paramModel.EndDate,
                    OrderStatus=paramModel.OrderStatus
                };
                _orderLocationReportRepository.Add(locationReport).SaveChanges();

                var reportRequestEvent = new ReportRequestEvent()
                {
                    ReportId = locationReport.Id
                };

                _reportEvents.SendReportRequest(reportRequestEvent);
                return new ApiResult(HttpStatusCode.OK, "Rapor talebi alındı");
            }
            catch (Exception)
            {
                //todo: add logging here
                return new ApiResult(HttpStatusCode.BadRequest, "Rapor talebiniz alınamadı. Lütfen tekrar deneyiniz.");
            }
        }


        public void CreateLocationReport(Guid reportId)
        {
            var locationReport = _orderLocationReportRepository.FirstOrDefault(x => x.Id == reportId);
            if (locationReport != null)
            {
                var orderInfoList = _orderClient.ListByDate(locationReport.StartDate, locationReport.EndDate, locationReport.OrderStatus).Data;
                var reportDetail = orderInfoList.GroupBy(c => c.OrderNumber)
                    .Select(loc => new OrderStatusReportDetail
                    {
                        OrderDate = loc.Select(x => x.OrderDate).FirstOrDefault(),
                        OrderNumber = loc.Select(x => x.OrderNumber).FirstOrDefault(),
                        IsCompleted = loc.Select(x => x.IsCompleted).FirstOrDefault(),
                        Customer= loc.Select(x => _customerClient.Get(x.CustomerId).Data).Select(y => new OrderCustomer
                        {
                            Id = y.Id,
                            CustomerName=y.CustomerName,
                            TaxOffice=y.TaxOffice,
                            TaxNumber=y.TaxNumber,
                            Adress=y.Adress                            
                        }
                        ).FirstOrDefault(),
                        
                        OrderStatusReportDetailItems = loc.Select(x => x.OrderItems.Select(y => new OrderStatusReportDetailItem
                        {
                            OrderDetailItemId = y.OrderId,
                            Price = y.Price,
                            Quantity=y.Quantity,
                            Product= loc.Select(x => _productClient.Get(y.ProductId).Data).Select(y => new OrderProduct
                            {
                                Id=y.Id,
                                ProductCode=y.ProductCode,
                                ProductName=y.ProductName,
                                Description=y.Description,
                                Price=y.Price
                            }
                        ).FirstOrDefault()
                        }
                        ).ToList()).FirstOrDefault()


                    }).ToList();
                locationReport.OrderStatusReportDetails = reportDetail;
                locationReport.ReportStatus = ReportStatus.Completed;
                _orderLocationReportRepository.Update(locationReport).SaveChanges();
            }
        }

        public ApiResult GetLocationReports()
        {
            var reports = _orderLocationReportRepository.GetAllAsNoTracking();
            return new ApiResult(HttpStatusCode.OK, reports);
        }

        public ApiResult GetLocationReportDetail(Guid reportId)
        {
            var reports = _orderLocationReportRepository.Where(x => x.Id == reportId)
                .Include(x => x.OrderStatusReportDetails).Select(x => x.OrderStatusReportDetails).AsNoTracking().AsEnumerable();
            return new ApiResult(HttpStatusCode.OK, reports);
        }
    }
}
