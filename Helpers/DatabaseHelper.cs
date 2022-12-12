using ADO.NET_Task3.Models;
using ADO.NET_Task3.ViewModels;
using ADO.NET_Task3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ADO.NET_Task3.Helpers
{
    public class DatabaseHelper
    {
        public static async Task AddProductsToCollectionFromDatabase(int skip_count, int get_count, ICollection<ProductUC> collection)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ConnectionString;
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT DISTINCT * FROM DistinctedProducts " +
                                        "WHERE ProductDescription <> '' " +
                                        "ORDER BY Id ASC " +
                                        "OFFSET @skip_count ROWS " +
                                        "FETCH NEXT @get_count ROWS ONLY ";

                var param1 = new SqlParameter()
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = skip_count,
                    ParameterName = "@skip_count"
                };

                var param2 = new SqlParameter()
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = get_count,
                    ParameterName = "@get_count"
                };

                command.Parameters.Add(param1);
                command.Parameters.Add(param2);

                var addedProductNames = new List<String>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Url = reader["Url"].ToString(),
                            Price = reader["Price"].ToString(),
                            Name = reader["Name"].ToString(),
                            Image = reader["Image"].ToString(),
                            BadgeType = reader["BadgeType"].ToString(),
                            ProductType = reader["ProductType"].ToString(),
                            ColourWayId = int.Parse(reader["ColourWayId"].ToString()),
                            IsSale = bool.Parse(reader["IsSale"].ToString()),
                            ReducedPrice = reader["ReducedPrice"].ToString(),
                            HasMultiplePrices = bool.Parse(reader["HasMultiplePrices"].ToString()),
                            IsOutlet = bool.Parse(reader["IsOutlet"].ToString()),
                            IsSellingFast = bool.Parse(reader["IsSellingFast"].ToString()),
                            PageNumber = int.Parse(reader["PageNumber"].ToString()),
                            TileId = int.Parse(reader["TileId"].ToString()),
                            Colour = reader["Colour"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            BaseUrl = reader["BaseUrl"].ToString(),
                            MainCategory = reader["MainCategory"].ToString(),
                            BrandName = reader["BrandName"].ToString(),
                            ProductRating = reader["ProductRating"].ToString(),
                            ProductCode = reader["ProductCode"].ToString(),
                            ProductDescription = reader["ProductDescription"].ToString()
                        };
                        var productView = new ProductUC();
                        product.Price += "$";
                        product.ReducedPrice += "$";
                        var productViewModel = new ProductUCViewModel(product);
                        productView.DataContext = productViewModel;
                        if (!addedProductNames.Contains(product.Name))
                        {
                            addedProductNames.Add(product.Name);
                            collection.Add(productView);
                        }
                    }
                }
            }
        }

        public static async Task DeleteProductById(int id)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ConnectionString;
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"DELETE FROM DistinctedProducts " +
                               "WHERE Id = @id"; ;

                var param = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    SqlValue = id,
                    ParameterName = "@id"
                };

                command.Parameters.Add(param);

                await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task UpdateProduct(Product product)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ConnectionString;
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"UPDATE DistinctedProducts " +
                                       "SET " +
                                       "Price = @price, " +
                                       "Colour = @colour, " +
                                       "CategoryName = @categoryName, " +
                                       "BrandName = @brandName, " +
                                       "ProductRating = @productRating, " +
                                       "ProductDescription = @productDescription " +
                                       "WHERE Id = @id";

                var param = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    SqlValue = product.Id,
                    ParameterName = "@id"
                };

                var param2 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.Price,
                    ParameterName = "@price"
                };

                var param3 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.Colour,
                    ParameterName = "@colour"
                };

                var param4 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.CategoryName,
                    ParameterName = "@categoryName"
                };

                var param5 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.BrandName,
                    ParameterName = "@brandName"
                };

                var param6 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.ProductRating,
                    ParameterName = "@productRating"
                };

                var param7 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.ProductDescription,
                    ParameterName = "@productDescription"
                };

                command.Parameters.Add(param);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}



