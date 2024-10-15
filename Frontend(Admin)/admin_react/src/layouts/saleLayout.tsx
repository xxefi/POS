import { Outlet, useLocation } from "react-router-dom";
import SalesMethods from "../pages/sale/salesMethods";

export default function SaleMethodsLayout() {
  const location = useLocation();
  const isSaleMethodRoute = location.pathname === "/sale/salesMethods";

  return isSaleMethodRoute ? <SalesMethods/> : <Outlet/>
}
