import { Outlet, useLocation } from "react-router-dom";
import CustomerGroup from "../pages/marketing/customerGroup";

export default function CustomerGroupLayout() {
  const location = useLocation();
  const isCustomerGroupRoute = location.pathname === "/marketing/customerGroup";

  return isCustomerGroupRoute ? <CustomerGroup /> : <Outlet />;
}
