import { useTranslation } from "react-i18next";
import { Search } from "@mui/icons-material";
import { Button } from "@mui/material";

export default function CustomerFilter() {
  const { t } = useTranslation("common");

  return (
    <form>
      <div className="grid gap-4">
        <div className="col-span-2">
          <label className="block text-sm font-medium text-gray-900">ID</label>
          <div className="relative flex flex-col">
            <input
              type="text"
              name="id"
              className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg block w-full pr-10 p-2.5"
              placeholder="ID"
            />
            <Search className="absolute right-3 top-1/2 transform -translate-y-1/2 opacity-50" />
          </div>
        </div>

        <div className="col-span-2">
          <label className="block text-sm font-medium text-gray-900">
            {t("name")}
          </label>
          <div className="relative flex flex-col">
            <input
              type="text"
              name="name"
              className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg block w-full pr-10 p-2.5"
              placeholder={t("name")}
            />
            <Search className="absolute right-3 top-1/2 transform -translate-y-1/2 opacity-50" />
          </div>
        </div>
        <div className="col-span-2">
          <label className="block text-sm font-medium text-gray-900">
            {t("phone")}
          </label>
          <div className="relative flex flex-col">
            <input
              type="text"
              name="phone"
              className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg block w-full pr-10 p-2.5"
              placeholder={t("phone")}
            />
            <Search className="absolute right-3 top-1/2 transform -translate-y-1/2 opacity-50" />
          </div>
        </div>
      </div>

      <Button
        type="submit"
        variant="contained"
        sx={{
          backgroundColor: "#000",
          color: "white",
          marginTop: "1rem",
          borderRadius: "10px",
          "&:hover": {
            backgroundColor: "#444",
          },
        }}
      >
        <span className="normal-case">{t("filter")}</span>
      </Button>
    </form>
  );
}
