using System.Collections;
using Dapper;
using Microsoft.Data.SqlClient;

public interface IOrderQueryService {
    Task<IEnumerable<OrderDTO>> GetOrdersAsync();
    Task<OrderDTO> GetOrderByIdAsync(int id);
    Task<IEnumerable<OrderItemDTO>> GetOrderItemsDTO(int orderId);
}
public class OrderQueryService :IOrderQueryService{
    public async Task<IEnumerable<OrderDTO>> GetOrdersAsync() {
        using(var connection = new SqlConnection("Server=localhost,1433;Database=Qasas;User Id= SA;Password=Hamada1020;TrustServerCertificate=True")){
            string query = "select * from dbo.Orders";
            var reader = await connection.QueryMultipleAsync(query);
            var data = reader.Read<OrderDTO>();
            return data;
        }
    }
    public async Task<OrderDTO> GetOrderByIdAsync(int id) {

        using(var connection = new SqlConnection("Server=localhost,1433;Database=Qasas;User Id= SA;Password=Hamada1020;TrustServerCertificate=True")) {

            var parameters = new DynamicParameters();
            parameters.Add("orderId", id);
            var query = @"select * from dbo.Orders where Id=@orderId";
            var data = await connection.QuerySingleAsync<OrderDTO>(query, parameters);
            return data;
        }
    }

    public async Task<IEnumerable<OrderItemDTO>> GetOrderItemsDTO(int orderId) {
        using(var connection = new SqlConnection("Server=localhost,1433;Database=Qasas;User Id= SA;Password=Hamada1020;TrustServerCertificate=True")){
            var parameters = new DynamicParameters();
            parameters.Add("orderId", orderId);
            var query = @"select * from dbo.OrderItem where OrderId=@orderId";
            var reader = await connection.QueryMultipleAsync(query, parameters);
            var data = reader.Read<OrderItemDTO>();
            return data;
        }
    }
}