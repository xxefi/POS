import { useTranslation } from "react-i18next";
import { RoleData } from "../../../interfaces/component.types";
import CheckCircleIcon from "@mui/icons-material/CheckCircle";
import CancelIcon from "@mui/icons-material/Cancel";

interface RoleTableProps {
  roles: RoleData[];
}

export default function RoleTable({ roles }: RoleTableProps) {
  const { t } = useTranslation("common");

  const renderIcon = (condition: boolean) => {
    return (
      <span
        className={`inline-flex items-center justify-center w-5 h-5 rounded-full ${
          condition ? "bg-green-100" : "bg-red-100"
        }`}
      >
        {condition ? (
          <CheckCircleIcon
            className="text-green-500"
            style={{ fontSize: "16px" }}
          />
        ) : (
          <CancelIcon className="text-red-500" style={{ fontSize: "16px" }} />
        )}
      </span>
    );
  };

  return (
    <div className="mt-5 overflow-x-auto rounded-xl shadow-lg">
      <table
        className="min-w-full bg-white border-separate"
        style={{ borderSpacing: "5" }}
      >
        <thead>
          <tr className="text-gray-700">
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tl-lg">
              ID
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("title")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("webAccess")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("terminalAccess")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("seller")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("courier")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {roles.length === 0 ? (
            <tr>
              <td
                colSpan={6}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            roles.map((role, index) => (
              <tr
                key={role.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{role.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{role.title}</span>
                </td>
                <td className="py-3 px-4">{renderIcon(role.webAccess)}</td>
                <td className="py-3 px-4">{renderIcon(role.terminalAccess)}</td>
                <td className="py-3 px-4">{renderIcon(role.seller)}</td>
                <td className="py-3 px-4 rounded-r-lg">
                  {renderIcon(role.courier)}
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
