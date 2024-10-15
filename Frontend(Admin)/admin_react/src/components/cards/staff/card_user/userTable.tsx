import { useTranslation } from "react-i18next";
import { UsersData } from "../../../interfaces/component.types";

interface UserTableProps {
  users: UsersData[];
}

export default function UserTable({ users }: UserTableProps) {
  const { t } = useTranslation("common");

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
              <span>{t("username")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("role")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("salary")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("email")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("phone")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>PIN</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("code")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tl-rg">
              <span>{t("salary")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {users.length === 0 ? (
            <tr>
              <td
                colSpan={9}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            users.map((user, index) => (
              <tr
                key={user.id}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{user.id}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.username}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.role}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.salary}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.email}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.phone}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.pin}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{user.code}</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{user.lastLogin}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}
