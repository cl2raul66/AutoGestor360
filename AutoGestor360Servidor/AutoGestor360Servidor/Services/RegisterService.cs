using AutoGestor360Servidor.Models;
using LiteDB;

namespace Servidor.Services;

public interface IRegisterService
{
    IEnumerable<Register> GetRegisters();
    bool UpsertRegister(Register entity);
}

public class RegisterService : IRegisterService
{
    readonly ILiteCollection<Register> collection;
    string DIR_DB = Path.Combine(AppContext.BaseDirectory, "db");

    public RegisterService()
    {
        if (!Directory.Exists(DIR_DB))
        {
            Directory.CreateDirectory(DIR_DB);
        }
        var cnx = new ConnectionString()
        {
            Filename = Path.Combine(DIR_DB, "Register.db")
        };

        LiteDatabase db = new(cnx);
        collection = db.GetCollection<Register>();
    }

    //public IEnumerable<Register> GetRegisters => collection.FindAll();
    public IEnumerable<Register> GetRegisters()
    {
        var c = collection.FindAll(); 
        return c;
    }

    public bool UpsertRegister(Register entity) => collection.Upsert(entity);
}
