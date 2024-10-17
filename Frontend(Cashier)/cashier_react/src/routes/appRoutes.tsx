import { Route, Routes } from "react-router-dom";
import { routes } from "./route.tsx";

export default function AppRoutes() {
  const renderRoutes = (routeList: any[]) => {
    return routeList.map((route, index) => (
      <Route key={index} path={route.path} element={route.element}>
        {route.children && renderRoutes(route.children)}
      </Route>
    ));
  };
  return <Routes>{renderRoutes(routes)}</Routes>;
}
