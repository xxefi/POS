import { Outlet, useLocation } from "react-router-dom";
import Customers from "../pages/marketing/customers";

export default function CustomerLayout() {
  const location = useLocation();
  const isCustomerRoute = location.pathname === "/marketing/customers";

  return isCustomerRoute ? <Customers /> : <Outlet />;
}
