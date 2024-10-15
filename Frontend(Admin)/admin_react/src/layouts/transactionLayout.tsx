import { Outlet, useLocation } from "react-router-dom";
import Transactions from "../pages/finances/transactions";

export default function TransactionLayout() {
  const location = useLocation();
  const isTransactionRoute = location.pathname === "/finances/transactions";

  return isTransactionRoute ? <Transactions/> : <Outlet/>
}
