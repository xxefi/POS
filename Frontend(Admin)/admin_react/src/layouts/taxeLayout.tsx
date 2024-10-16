import { Outlet, useLocation } from "react-router-dom";
import Taxes from "../pages/settings/taxes";

export default function TaxeLayout() {
  const location = useLocation();
  const isTaxeRoute = location.pathname === "/settings/taxes";

  return isTaxeRoute ? <Taxes /> : <Outlet />;
}
