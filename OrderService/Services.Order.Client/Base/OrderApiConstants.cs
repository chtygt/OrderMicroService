namespace Services.Order.Client.Base;

public static class OrderApiConstants
{
    #region Order
    public const string OrderGet = "Order/Get";
    public const string OrderAdd = "Order/Add";
    public const string OrderUpdate = "Order/Update";
    public const string OrderDelete = "Order/Delete";
    public const string OrderList = "Order/List";
    public const string OrderListByDate = "Order/ListByDate";
    public const string OrderCount = "Order/Count";
    #endregion

    #region OrderItem
    public const string OrderItemGet = "OrderItem/Get";
    public const string OrderItemAdd = "OrderItem/Add";
    public const string OrderItemUpdate = "OrderItem/Update";
    public const string OrderItemDelete = "OrderItem/Delete";
    public const string OrderItemList = "OrderItem/List";
    public const string OrderItemListAll = "OrderItem/ListAll";
    public const string OrderItemCount = "OrderItem/Count";
    #endregion 
}