import { Outlet } from "react-router-dom";
import { useEffect, useState } from "react";
import { CircularProgress } from "@mui/material";
import Navbar from "../navbar/navbar";

export default function Layout() {
  const [loading, setLoading] = useState<boolean | null>(true);
  useEffect(() => {
    const timer = setTimeout(() => {
      setLoading(false);
    }, 500);
    return () => clearTimeout(timer);
  }, []);

  if (loading) {
    return (
      <div className="flex justify-center items-center h-screen">
        <CircularProgress sx={{ color: "black" }} />
      </div>
    );
  }

  return (
    <div className="flex">
      <Navbar />
      <div className="flex-grow p-4 flex flex-col mt-4">
        <Outlet />
      </div>
    </div>
  );
}
