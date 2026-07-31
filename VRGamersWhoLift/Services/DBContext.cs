using VRGamersWhoLift.Models.database;

namespace VRGamersWhoLift.Services
{
    public interface IDBContext
    {
        public VRGamersWhoLiftContext initiateContext();
    }
    public class DBContext : IDBContext
    {
        private VRGamersWhoLiftContext context;

        public DBContext(VRGamersWhoLiftContext context)
        {
            this.context = context;
        }

        VRGamersWhoLiftContext IDBContext.initiateContext()
        {
            return context;
        }
    }
}
