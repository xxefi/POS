import { Group } from "@mui/icons-material";
import { Button } from "@mui/material";
import { NavLink } from "react-router-dom";
import { activeStyle, buttonStyle } from "../components/styles/button.styles";
import { staffItem, StaffItem } from "../components/interfaces/staff.item";
import { ComponentProps } from "../components/interfaces/component.props";

export default function Staff({ t, setOpen, open }: ComponentProps) {
  const renderStaffItem = (item: StaffItem) => (
    <li key={item.to}>
      <Button
        component={NavLink}
        to={item.to}
        variant="text"
        sx={{
          ...buttonStyle,
          color: (theme) => (theme.palette.mode === "dark" ? "white" : "black"),
          "&.active": activeStyle,
        }}
      >
        <span>{t(item.label)}</span>
      </Button>
    </li>
  );
  return (
    <li className="mb-2">
      <button
        onClick={() => setOpen(!open)}
        className="flex items-center justify-between bg-white rounded-xl w-full text-left p-2 rounded hover:bg-gray-200 focus:outline-none"
      >
        <span className="flex items-center">
          <Group className="mr-2" />
          {t("staff")}
        </span>
        <svg
          className={`w-4 h-4 transition-transform duration-200 ${
            open ? "transform rotate-90" : ""
          }`}
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth={2}
            d="M6 18L18 6M6 6l12 12"
          />
        </svg>
      </button>
      <div
        className={`overflow-hidden bg-white rounded-xl mt-1 transition-all duration-500 ease-in-out ${
          open ? "max-h-40" : "max-h-0 overflow-hidden"
        }`}
      >
        <ul
          className={`list-none p-0 transition-opacity duration-500 ${
            open ? "opacity-100" : "opacity-0"
          }`}
        >
          {staffItem.map(renderStaffItem)}
        </ul>
      </div>
    </li>
  );
}
