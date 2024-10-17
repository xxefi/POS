import Login from "../pages/login";
import { RouteConfig } from "../components/interfaces/route.config";
import Layout from "../layouts/layout";
import NotFound from "./notfound";

export const routes: RouteConfig[] = [
  {
    path: "/",
    element: <Layout />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "*",
    element: <NotFound />,
  },
];
