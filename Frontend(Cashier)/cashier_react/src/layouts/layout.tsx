import { Outlet } from "react-router-dom";

export default function Layout() {
  return (
    <div className="flex">
      <a href="/login">login</a>
      <div className="flex-grow p-4 flex flex-col mt-4">
        <Outlet />
      </div>
    </div>
  );
}
