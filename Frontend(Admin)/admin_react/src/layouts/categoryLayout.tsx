import { Outlet, useLocation } from "react-router-dom";
import Categories from "../pages/finances/categories";

export default function CategoryLayout() {
  const location = useLocation();
  const isCategoryRoute = location.pathname === "/finances/categories";

  return isCategoryRoute ? <Categories/> : <Outlet/>
}
