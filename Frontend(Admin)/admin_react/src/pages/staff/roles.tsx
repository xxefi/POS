import { useEffect } from "react";
import { useTranslation } from "react-i18next";
import { Button } from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import { RoleData } from "../../components/interfaces/component.types";
import RoleTable from "../../components/cards/staff/card_roles/roleTable";
import { Link } from "react-router-dom";

const roles: RoleData[] = [];

export default function Roles() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("roles");
  }, []);
  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">{t("roles")}</span>

      <div className="flex items-center mt-4">
        <Button
          component={Link}
          to="/staff/roles/create"
          variant="contained"
          sx={{
            color: "white",
            textTransform: "none",
            width: "110px",
            borderRadius: "10px",
            boxShadow: "none",
          }}
        >
          <span className="flex items-center justify-center">
            <AddIcon sx={{ fontSize: "20px" }} />
            <span className="ml-2 text-sm">{t("create")}</span>
          </span>
        </Button>
      </div>

      <RoleTable roles={roles} />
    </div>
  );
}
