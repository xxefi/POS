import { useTranslation } from "react-i18next";
import { ReceiptData } from "../../../interfaces/component.types.ts";
import { ChangeEvent, useState } from "react";
import { TablePagination } from "@mui/material";

interface ReceiptsTableProps {
  receipts: ReceiptData[];
}

export default function ReceiptsTable({ receipts }: ReceiptsTableProps) {
  const { t } = useTranslation("common");
  const [page, setPage] = useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);

  const handleChangePage = (newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (e: ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(parseInt(e.target.value));
    setPage(0);
  };
  return (
    <div className="mt-5 overflow-x-auto rounded-xl shadow-lg">
      <table
        className="min-w-full bg-white border-separate"
        style={{ borderSpacing: "1" }}
      >
        <thead>
          <tr className="text-gray-700">
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tl-lg">
              <span>ID</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("staff")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("createdAt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("closedAt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("terminal")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("table")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("subtotal")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {receipts.length === 0 ? (
            <tr>
              <td
                colSpan={8}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            receipts.map((receipt, index) => (
              <tr
                key={receipt.receiptId}
                className={`bg-white shadow-sm hover:bg-gray-100 ${
                  index % 2 === 0 ? "bg-gray-50" : "bg-white"
                }`}
              >
                <td className="py-3 px-4 rounded-l-lg">
                  <span>{receipt.receiptId}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{receipt.staff}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{receipt.createdAt}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{receipt.closedAt}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{receipt.terminal}</span>
                </td>
                <td className="py-3 px-4">
                  <span>{receipt.table}</span>
                </td>
                <td className="py-3 px-4 rounded-r-lg">
                  <span>{receipt.subtotal}</span>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25, 50, 100]}
        component="div"
        count={receipts.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={(_, newPage) => handleChangePage(newPage)}
        onRowsPerPageChange={handleChangeRowsPerPage}
        labelRowsPerPage={t("rowsPerPage")}
      />
    </div>
  );
}
