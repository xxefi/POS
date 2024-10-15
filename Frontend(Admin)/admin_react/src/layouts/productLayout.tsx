import {Outlet, useLocation} from "react-router-dom";
import Products from "../pages/menu/products.tsx";

export default function ProductLayout() {
    const location = useLocation();
    const isProducts = location.pathname === '/menu/products';

    return isProducts ? <Products/> : <Outlet/>
}