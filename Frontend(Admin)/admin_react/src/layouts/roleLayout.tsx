import { Outlet, useLocation } from "react-router-dom";
import Roles from "../pages/staff/roles";

export default function RoleLayout() {
  const location = useLocation();
  const isRoleRoute = location.pathname === "/staff/roles";

  return isRoleRoute ? <Roles /> : <Outlet />;
}
