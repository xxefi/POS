import { useTranslation } from "react-i18next";
import { Search } from "@mui/icons-material";
import { Button } from "@mui/material";

export default function CategoryMenuFilter() {
    const { t } = useTranslation("common");

    return (
        <form>
            <div className="grid gap-4">
                <label className="block text-sm font-medium text-gray-900">ID</label>
                <div className="relative flex flex-col col-span-2">
                    <input
                        type="text"
                        name="id"
                        id="id"
                        className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg block w-full pr-10 p-2.5"
                        placeholder="ID"
                    />
                    <Search className="absolute right-3 top-1/2 transform -translate-y-1/2 opacity-50" />
                </div>

                <div className="col-span-2">
                    <label className="block mb-2 text-sm font-medium text-gray-900">
                        {t("category")}
                    </label>
                    <select
                        className="bg-white border border-gray-300 text-gray-900 text-sm rounded-lg block w-full p-2.5"
                    >
                        <option value="" disabled>
                            {t("selectCategory")}
                        </option>
                    </select>
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
