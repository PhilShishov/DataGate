//namespace DataGate.Data.Repositories
//{
//    using DataGate.Common;
//    using DataGate.Data.Common.Repositories.UsersContext;
//    using DataGate.Data.Models.Columns;
//    using DataGate.Data.Repositories.UsersContext;

//    public class RepositorySwapper
//    {
//        public static IUserRepository<T> ByController<T>(string controller, IUserRepository<T> repository)
//            where T : IUserColumn
//        {

//            repository

//            switch (controller)
//            {
//                case EndpointsConstants.FundsController:
//                case EndpointsConstants.FundArea + EndpointsConstants.DisplaySub + EndpointsConstants.FundsController:
//                    repository = fund;
//                    break;
//                case EndpointsConstants.DisplaySub + EndpointsConstants.FundsController:
//                case EndpointsConstants.SubFundShareClassesController:
//                    repository = subFund;
//                    break;
//                case EndpointsConstants.ShareClassesController:
//                    repository = subFund;
//                    break;
//            }

//            return repository;
//        }
//    }
//}