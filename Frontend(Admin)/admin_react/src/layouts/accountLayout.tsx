import { Outlet, useLocation } from "react-router-dom";
import Accounts from "../pages/finances/accounts";

export default function AccountLayout() {
  const location = useLocation();
  const isAccountRoute = location.pathname === "/finances/accounts";

  return isAccountRoute ? <Accounts/> : <Outlet/>;
}
