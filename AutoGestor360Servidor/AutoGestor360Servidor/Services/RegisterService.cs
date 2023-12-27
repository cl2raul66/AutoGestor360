using AutoGestor360Servidor.Models;
using LiteDB;

namespace Servidor.Services;

public interface IRegisterService
{
    bool Exist { get; }

    bool Delete(string id);
    IEnumerable<Register> GetAll();
    Register GetById(string id);
    bool Upsert(Register entity);
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

    public bool Exist => collection.Count() > 0;

    public IEnumerable<Register> GetAll() => collection.FindAll();

    public Register GetById(string id) => collection.FindById(id);

    public bool Upsert(Register entity) => collection.Upsert(entity);

    public bool Delete(string id) => collection.Delete(id);
}

