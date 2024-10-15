import {Outlet, useLocation} from "react-router-dom";
import CategoriesMenu from "../pages/menu/categoriesMenu.tsx";
export default function CategoryMenuLayout() {
    const location = useLocation();
    const isCategoryMenuRoute = location.pathname === "/menu/categories";

    return isCategoryMenuRoute ? <CategoriesMenu/> : <Outlet/>
}