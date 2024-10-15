import { Outlet, useLocation } from "react-router-dom";
import Users from "../pages/staff/users";

export default function UserLayout() {
  const location = useLocation();
  const isUserRoute = location.pathname === "/staff/users";

  return isUserRoute ? <Users /> : <Outlet />;
}
