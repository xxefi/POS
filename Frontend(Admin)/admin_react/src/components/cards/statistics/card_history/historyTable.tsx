import { HistoryData } from "../../../interfaces/component.types.ts";
import { useTranslation } from "react-i18next";
import { ChangeEvent, useState } from "react";
import { TablePagination } from "@mui/material";

interface HistoryTableProps {
  histories: HistoryData[];
}

export default function HistoryTable({ histories }: HistoryTableProps) {
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
              <span>{t("receipt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("createdAt")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("terminal")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left">
              <span>{t("receiptOperations")}</span>
            </td>
            <td className="py-3 px-4 bg-gray-100 text-left rounded-tr-lg">
              <span>{t("price")}</span>
            </td>
          </tr>
        </thead>
        <tbody>
          {histories.length === 0 ? (
            <tr>
              <td
                colSpan={5}
                className="py-3 px-4 text-center bg-white rounded-lg shadow-sm"
              >
                <span>{t("noDataFound")}</span>
              </td>
            </tr>
          ) : (
            histories
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((history, index) => (
                <tr
                  key={history.receiptId}
                  className={`bg-white shadow-sm hover:bg-gray-100 ${
                    index % 2 === 0 ? "bg-gray-50" : "bg-white"
                  }`}
                >
                  <td className="py-3 px-4 rounded-l-lg">
                    <span>{history.receiptId}</span>
                  </td>
                  <td className="py-3 px-4">
                    <span>{history.createdAt}</span>
                  </td>
                  <td className="py-2 px-4">
                    <span>{history.terminal}</span>
                  </td>
                  <td className="py-2 px-4">
                    <span>{history.receiptOperations}</span>
                  </td>
                  <td className="py-2 px-4 rounded-r-lg">
                    <span>{history.price}</span>
                  </td>
                </tr>
              ))
          )}
        </tbody>
      </table>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25, 50, 100]}
        component="div"
        count={histories.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={(_, newPage) => handleChangePage(newPage)}
        onRowsPerPageChange={handleChangeRowsPerPage}
        labelRowsPerPage={t("rowsPerPage")}
      />
    </div>
  );
}
