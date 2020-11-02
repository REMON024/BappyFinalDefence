using Context;
using ElectricBillPayment.Common.Utility;
using ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ElectricBillPayment.BLL
{
   public class UserBLLManager: IUserBLLManager
    {
        private readonly PaymentDbContext _dbContext;
        public UserBLLManager(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }  

        public User AddUser(User user)
        {
            try
            {
                user.CreatedBy = "Admin";
                user.UpdatedDate = DateTime.Now;
                user.Status = (int)ElectricBillPayment.Common.Enum.Enum.Status.Active;
                user.Password = new EncryptionService().Encrypt(user.Password);
                _dbContext.User.Add(user);
                _dbContext.SaveChanges();
                return user;

            }
            catch (Exception ex)
            {
                return user;
                throw;
            }

        }

        public List<User> GetAll()
        {
            List<User> user = _dbContext.User.Where(p => p.Status == (int)ElectricBillPayment.Common.Enum.Enum.Status.Active).ToList();
            return user;
        }


        public User UpdateUser(User user)
        {
            try
            {
                user.UpdatedBy = "Admin";
                user.UpdatedDate = DateTime.Now;
                _dbContext.User.Update(user);
                _dbContext.SaveChanges();
                return user;

            }
            catch (Exception ex)
            {
                return user;
                throw;
            }
        }
    }


    public interface IUserBLLManager
    {
        User AddUser(User user);
        List<User> GetAll();
        User UpdateUser(User user);
    }
}
