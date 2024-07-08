using Dapper;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Reflection;


namespace Osoft.SiparisOnay.Repository.Helpers
{
    public class GenerateSql<T> where T : class
    {
        public static string Add(T entity)
        {
            //tabloda [Key] autoincrement varsa onu bulur ve aşağıda bunu sql e dahil etmez.
            string idName = "";
            foreach (var p in entity.GetType().GetProperties())
            {
                if (p.GetCustomAttributes().FirstOrDefault() != null)
                {
                    if (p.GetCustomAttributes().FirstOrDefault().ToString() == "System.ComponentModel.DataAnnotations.KeyAttribute")
                    {
                        idName = p.Name;
                        break;
                    }
                }
            }

            Types types = new Types();
            string sql = @$"INSERT INTO {typeof(T).Name} ", columName = "(", valuName = "(";
            foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
            {

                // modelde ? işareti varsa nullable tipler için aşağıdaki kodları yazıyoruz. System.Nullable`1 şeklinde geldiği için sorun oluyordu.
                Type propType = p.PropertyType; string typeName;
                if (Nullable.GetUnderlyingType(propType) == null)
                {
                    typeName = p.GetMethod.ReturnType.Name;
                }
                else
                {
                    typeName = Nullable.GetUnderlyingType(propType).Name;
                }

                //model klasöründe oluşturulan tipler döner. Amaç sadece modellerin gelmesi. Eğer bir class varsa onlar almaz.
                foreach (var p2 in types.GetType().GetProperties())
                {
                    if (typeName == p2.GetMethod.ReturnType.Name) // model içindeki tipler gelir. Ama model içinde farklı bir model varsa gelmez
                    {
                        if (p.Name != idName && p.Name != "Where") // [Key] autoincrement için ilk column insert query ye eklenmaz.
                        {
                            if (p.Name.IndexOf("cmpt") == -1) // cmpt ile başlayanları alma
                            {
                                columName = columName + p.Name + ",";
                                valuName = valuName + ":" + p.Name + ",";
                            }
                        }
                    }
                }
            }

            columName = columName.Remove(columName.Length - 1, 1) + ")";
            valuName = valuName.Remove(valuName.Length - 1, 1) + @$");SELECT @@IDENTITY FROM {typeof(T).Name}";

            sql = sql + columName + " VALUES " + valuName;
            //Console.WriteLine(sql);
            return sql;
            // tüm model dönecek
        }

        public static DynamicParameters Parameters(T entity)
        {

            string where = "";
            string idName = "";
            DynamicParameters parameters = new DynamicParameters();
            Types types = new Types();

            //where şartı varsa buradan alır. Where object olduğu için entity içinden aşağıdaki kod ile alıyoruz.
            foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
            {
                if (p.Name == "Where")
                {
                    if (p.GetValue(entity) != null)
                    {
                        string json = p.GetValue(entity).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                        var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                        foreach (var item in values)
                        {
                            where = where + item.Key + "='" + item.Value + "' AND ";
                        }
                    }

                }
            }

            //where şartı geldiyse where şartına göre yoksa primary key e göre parametre doldurur.
            if (where != "")
            {

                foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
                {

                    // modelde ? işareti varsa nullable tipler için aşağıdaki kodları yazıyoruz. System.Nullable`1 şeklinde geldiği için sorun oluyordu.
                    Type propType = p.PropertyType; string typeName;
                    if (Nullable.GetUnderlyingType(propType) == null)
                    {
                        typeName = p.GetMethod.ReturnType.Name;
                    }
                    else
                    {
                        typeName = Nullable.GetUnderlyingType(propType).Name;
                    }

                    //model klasöründe oluşturulan tipler döner. Amaç sadece modellerin gelmesi. Eğer bir class varsa onlar almaz.
                    foreach (var p2 in types.GetType().GetProperties())
                    {
                        if (typeName == p2.GetMethod.ReturnType.Name) // model içindeki tipler gelir. Ama model içinde farklı bir model varsa gelmez
                        {
                            //Console.WriteLine(p2.GetMethod.ReturnType.Name+" - "+ typeName);
                            if (p.Name != "Where") // autoincrement için ilk column insert query ye eklenmaz.
                            {
                                if (p.Name.IndexOf("cmpt") == -1) // cmpt ile başlayanları alma
                                {
                                    var a = p.GetValue(entity);
                                    if (p.GetMethod.ReturnType.Name == "String")
                                    {
                                        a = a.ToString().Trim();
                                    }
                                    parameters.Add(p.Name, a);
                                }

                            }
                        }
                    }
                }
                return parameters;
            }
            else
            {
                //tabloda [Key] autoincrement varsa onu bulur ve aşağıda bunu sql e dahil etmez.
                foreach (var p in entity.GetType().GetProperties())
                {
                    if (p.GetCustomAttributes().FirstOrDefault() != null)
                    {
                        if (p.GetCustomAttributes().FirstOrDefault().ToString() == "System.ComponentModel.DataAnnotations.KeyAttribute")
                        {
                            idName = p.Name;
                            break;
                        }
                    }
                }

                foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
                {


                    // modelde ? işareti varsa nullable tipler için aşağıdaki kodları yazıyoruz. System.Nullable`1 şeklinde geldiği için sorun oluyordu.
                    Type propType = p.PropertyType; string typeName;
                    if (Nullable.GetUnderlyingType(propType) == null)
                    {
                        typeName = p.GetMethod.ReturnType.Name;
                    }
                    else
                    {
                        typeName = Nullable.GetUnderlyingType(propType).Name;
                    }

                    //model klasöründe oluşturulan tipler döner. Amaç sadece modellerin gelmesi. Eğer bir class varsa onlar almaz.
                    foreach (var p2 in types.GetType().GetProperties())
                    {
                        if (typeName == p2.GetMethod.ReturnType.Name) // model içindeki tipler gelir. Ama model içinde farklı bir model varsa gelmez
                        {
                            //Console.WriteLine(p2.GetMethod.ReturnType.Name+" - "+ typeName);
                            if (p.Name != idName && p.Name != "Where") // autoincrement için ilk column insert query ye eklenmaz.
                            {
                                if (p.Name.IndexOf("cmpt") == -1) // cmpt ile başlayanları alma
                                {
                                    var a = p.GetValue(entity);
                                    if (p.GetMethod.ReturnType.Name == "String")
                                    {
                                        a = a.ToString().Trim();
                                    }
                                    parameters.Add(p.Name, a);
                                }

                            }
                        }
                    }
                }
            }

            return parameters;
        }


        public static string GetById(T entity, int id)
        {
            int i = 0;
            string sql = "";
            foreach (var p in entity.GetType().GetProperties())
            {
                i++;
                if (i == 1)
                {
                    sql = @$"SELECT * FROM {typeof(T).Name} WHERE  {p.Name} = {id} ";
                }
            }
            return sql;
        }

        public static string Detele(T entity, int id)
        {
            int i = 0;
            string sql = "";
            foreach (var p in entity.GetType().GetProperties())
            {
                i++;
                if (i == 1)
                {
                    sql = @$"DELETE TOP 1 FROM {typeof(T).Name} WHERE  {p.Name} = {id} ";
                }
            }
            return sql;
        }

        public static string DeleteAll(T entity, int id, string field)
        {
            string sql = @$"DELETE FROM {typeof(T).Name} WHERE  {field} = {id}";
            return sql;
        }


        public static string Update(T entity)
        {
            string where = "";
            Types types = new Types();
            string sql = @$"UPDATE {typeof(T).Name} SET ", columName = "";

            //where şartı varsa buradan alır. Where object olduğu için entity içinden aşağıdaki kod ile alıyoruz.
            foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
            {
                if (p.Name == "Where")
                {
                    if (p.GetValue(entity) != null)
                    {
                        string json = p.GetValue(entity).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                        var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                        foreach (var item in values)
                        {
                            where = where + item.Key + "='" + item.Value + "' AND ";
                        }
                    }

                }
            }


            //WHERE şartı geldiyse where şartına göre yoksa primary key ile update eder.
            if (where != "")
            {
                foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
                {
                    foreach (var p2 in types.GetType().GetProperties())
                    {

                        // modelde ? işareti varsa nullable tipler için aşağıdaki kodları yazıyoruz. System.Nullable`1 şeklinde geldiği için sorun oluyordu.
                        Type propType = p.PropertyType; string typeName;
                        if (Nullable.GetUnderlyingType(propType) == null)
                        {
                            typeName = p.GetMethod.ReturnType.Name;
                        }
                        else
                        {
                            typeName = Nullable.GetUnderlyingType(propType).Name;
                        }

                        if (typeName == p2.GetMethod.ReturnType.Name) // model içindeki tipler gelir. Ama model içinde farklı bir model varsa gelmez
                        {
                            if (p.Name != "Where") // where object gelmeyecek
                            {
                                if (p.Name.IndexOf("cmpt") == -1) // cmpt ile başlayanları alma
                                {
                                    columName = columName + p.Name + "=:" + p.Name + ",";
                                }
                            }
                        }
                    }
                }

                columName = columName.Remove(columName.Length - 1, 1) + " WHERE " + where.Substring(0, where.Length - 4);

            }
            else
            {
                //tabloda [Key] autoincrement varsa onu bulur ve aşağıda bunu sql e dahil etmez.
                string idName = "";
                int id = 0;
                foreach (var p in entity.GetType().GetProperties())
                {
                    if (p.GetCustomAttributes().FirstOrDefault() != null)
                    {
                        if (p.GetCustomAttributes().FirstOrDefault().ToString() == "System.ComponentModel.DataAnnotations.KeyAttribute")
                        {
                            idName = p.Name;
                            id = Int32.Parse(p.GetValue(entity).ToString());
                            break;
                        }
                    }
                }

                foreach (var p in entity.GetType().GetProperties().OrderBy(o => o.Name))
                {
                    foreach (var p2 in types.GetType().GetProperties())
                    {
                        // modelde ? işareti varsa nullable tipler için aşağıdaki kodları yazıyoruz. System.Nullable`1 şeklinde geldiği için sorun oluyordu.
                        Type propType = p.PropertyType; string typeName;
                        if (Nullable.GetUnderlyingType(propType) == null)
                        {
                            typeName = p.GetMethod.ReturnType.Name;
                        }
                        else
                        {
                            typeName = Nullable.GetUnderlyingType(propType).Name;
                        }

                        if (typeName == p2.GetMethod.ReturnType.Name) // model içindeki tipler gelir. Ama model içinde farklı bir model varsa gelmez
                        {
                            if (p.Name != idName && p.Name != "Where") // autoincrement için ilk column insert query ye eklenmaz.
                            {
                                if (p.Name.IndexOf("cmpt") == -1) // cmpt ile başlayanları alma
                                {
                                    columName = columName + p.Name + "=:" + p.Name + ",";
                                }
                            }
                        }
                    }
                }
                columName = columName.Remove(columName.Length - 1, 1) + " WHERE " + idName + "=" + id;
            }
            return sql = sql + columName;
        }
    }
}