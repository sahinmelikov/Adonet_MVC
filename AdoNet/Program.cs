using System.Data;
using System.Data.SqlClient;


string ConnectionString = "Server=DESKTOP-OV988OJ\\SAHIN;Database=AdeNot; Trusted_Connection=True;";

Console.WriteLine("1 reqemine basin");              ///////////////////////////////qeyd: view den ist etmisem deye cwdeki melumatlar evvel geldiyini dusunurem
int a =Convert.ToInt32(Console.ReadLine());
GetName();
async void GetName()
{
    using (SqlConnection coon = new SqlConnection(ConnectionString))
    {
        coon.Open();
        string commandtext = "SELECT * FROM Pizzas  INNER JOIN PRICES  ON Pizzas.ID=PRICES.PIZZAID inner Join PIZZATYPES on Pizzas.id=PIZZATYPES.TYPEID";
        using (SqlCommand cmd = new SqlCommand(commandtext, coon))
        {
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        if (a==1)
                        {
                        Console.WriteLine($"Pizza Id-> {reader[6]} Pizza Name-> {reader[1]}   PizzaType->{reader[7]}  Pizza Price-> {reader[5]}");


                        }

                    }

                }
                else
                {
                    Console.WriteLine("error");
                }
            }

        }

    }
}


//async void GetNameNew()
//{
//    using (SqlConnection coon = new SqlConnection(ConnectionString))
//    {
//        coon.Open();
//        string commandtext = "SELECT * FROM Pizzas  INNER JOIN PRICES  ON Pizzas.ID=PRICES.PIZZAID ";
//        using (SqlCommand cmd = new SqlCommand(commandtext, coon))
//        {
//            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
//            {
//                if (reader.HasRows)
//                {

//                    while (reader.Read())
//                    {
//                        Console.WriteLine("Pizzanin Adini daxil edin");
//                        string PizzaName = Console.ReadLine();


//                    }

//                }
//                else
//                {
//                    Console.WriteLine("error");
//                }
//            }

//        }

//    }
//}

//////////-----------------------------------
async void GetNamePizza()
{


    using (SqlConnection coon = new SqlConnection(ConnectionString))
    {

        coon.Open();
        string commandtext = "SELECT * FROM Pizzas  INNER JOIN PRICES  ON Pizzas.ID=PRICES.PIZZAID ";
        using (SqlCommand cmd = new SqlCommand(commandtext, coon))
        {
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Console.WriteLine($"Pizza Id-> {reader[6]} Pizza Name-> {reader[1]}   PizzaType->{reader[7]}  Pizza Price-> {reader[5]}");

                    }


                }





            }

        }

    }
}




Console.WriteLine("Pizza haqqında ətraflı məlumat almaq istəyirsizsə pizzanın İd -sini ,istəmirsizə 0 daxil edin");
int id1 = Convert.ToInt32(Console.ReadLine());

GetNameIff(id1);

Console.ReadLine();
async void GetNameIff(int id)
{
    using (SqlConnection coon = new SqlConnection(ConnectionString))
    {
        coon.Open();
        string commandtext = "SELECT * FROM Pizzas where id=" + id;
        string commandtext1 = "SELECT * FROM Pizzas id=" + id;

        using (SqlCommand cmd = new SqlCommand(commandtext, coon))
        {
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (id == id1)
                        {
                            Console.WriteLine($"Pizza Id-> {reader[0]} Pizza Name-> {reader[1]}   Description->{reader[2]}  CategoryId-> {reader[3]}");


                        }

                    }
                }


                else if (id1 == 0)
                {

                    GetNamePizza();

                    Console.WriteLine("8 reqemine basaraq Oz Pizzani sifaris ver");
                    if (id1==8)
                    {
                        Console.WriteLine("Pizzanin adini daxil edin");
                        string name = Console.ReadLine();
                        Console.WriteLine("Ingredientlerini yazin");
                        int InnergredientId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Pizzanin Olcusunu teyin edin");
                        string pizzaSize = Console.ReadLine();
                        Console.WriteLine("Qiymet daxil edin");
                        int PizzaPrice = Convert.ToInt32(Console.ReadLine());
                        InsertStudent(name, InnergredientId, pizzaSize, PizzaPrice);
                        Console.ReadLine();
                        async void InsertStudent(string name, object InnergredientId, string pizzaSize, int PizzaPrice)
                        {
                            using (SqlConnection conn = new SqlConnection(ConnectionString))
                            {
                                conn.Open();
                                string commandtext = "INSERT INTO PizzaUp values(@name,@InnergredientId,@pizzaSize,@PizzaPrice)";
                                using (SqlCommand cmd = new SqlCommand(commandtext, conn))
                                {
                                    SqlParameter[] parms = new SqlParameter[]
                                    {
                CreateSqlparametr("name",SqlDbType.NVarChar,name),
                CreateSqlparametr("InnergredientId",SqlDbType.Int,InnergredientId),
                CreateSqlparametr("pizzaSize",SqlDbType.NVarChar,pizzaSize),
                CreateSqlparametr("PizzaPrice",SqlDbType.Int,PizzaPrice),

                                    };


                                    cmd.Parameters.AddRange(parms);
                                    int result = cmd.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        await Console.Out.WriteLineAsync("Ok");
                                    }
                                    else
                                    {
                                        await Console.Out.WriteLineAsync("Not OK");
                                    }
                                }

                            }
                        }

                        SqlParameter CreateSqlparametr(string name, SqlDbType sqlDbType, object newObj)
                        {
                            SqlParameter sqlParameter = new SqlParameter(name, sqlDbType);
                            sqlParameter.Value = newObj;
                            return sqlParameter;
                        }

                    }

                }
                else
                {
                    Console.WriteLine("Bu Id-ye uygun Pizza Bazada Yoxdur");
                }
            }

        }


    }
}



Console.WriteLine("Pizzanin adini daxil edin");
string name = Console.ReadLine();
Console.WriteLine("Ingredientlerini yazin");
int InnergredientId = Convert.ToInt32( Console.ReadLine());
Console.WriteLine("Pizzanin Olcusunu teyin edin");
string pizzaSize = Console.ReadLine();
Console.WriteLine("Qiymet daxil edin");
int PizzaPrice = Convert.ToInt32(Console.ReadLine());
InsertStudent(name, InnergredientId, pizzaSize, PizzaPrice);
Console.ReadLine();
async void InsertStudent(string name, object InnergredientId, string pizzaSize, int PizzaPrice)
{
    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string commandtext = "INSERT INTO PizzaUp values(@name,@InnergredientId,@pizzaSize,@PizzaPrice)";
        using (SqlCommand cmd = new SqlCommand(commandtext, conn))
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                CreateSqlparametr("name",SqlDbType.NVarChar,name),
                CreateSqlparametr("InnergredientId",SqlDbType.Int,InnergredientId),
                CreateSqlparametr("pizzaSize",SqlDbType.NVarChar,pizzaSize),
                CreateSqlparametr("PizzaPrice",SqlDbType.Int,PizzaPrice),

            };


            cmd.Parameters.AddRange(parms);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                await Console.Out.WriteLineAsync("Ok");
            }
            else
            {
                await Console.Out.WriteLineAsync("Not OK");
            }
        }

    }
}

SqlParameter CreateSqlparametr(string name, SqlDbType sqlDbType, object newObj)
{
    SqlParameter sqlParameter = new SqlParameter(name, sqlDbType);
    sqlParameter.Value = newObj;
    return sqlParameter;
}







