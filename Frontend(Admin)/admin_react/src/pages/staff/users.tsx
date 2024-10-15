import { Button } from "@mui/material";
import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import MenuIcon from "@mui/icons-material/Menu";
import AddIcon from "@mui/icons-material/Add";
import { Link } from "react-router-dom";
import UserTable from "../../components/cards/staff/card_user/userTable";
import { UsersData } from "../../components/interfaces/component.types";
import UserModal from "../../components/cards/staff/card_user/userModal";

const user: UsersData[] = [];

export default function Users() {
  const { t } = useTranslation("common");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  useEffect(() => {
    document.title = t("users");
  }, []);
  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">{t("users")}</span>

      <div className="flex justify-between items-center mt-4">
        <Button
          onClick={() => setIsModalOpen(true)}
          variant="contained"
          sx={{
            backgroundColor: "rgb(242, 244, 248)",
            color: "black",
            textTransform: "none",
            width: "120px",
            borderRadius: "10px",
            boxShadow: "none",
          }}
        >
          <span className="flex items-center justify-center">
            <MenuIcon sx={{ fontSize: "20px" }} />
            <span className="ml-2 text-sm">{t("filters")}</span>
          </span>
        </Button>

        <Button
          component={Link}
          to="/staff/users/create"
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

      <UserTable users={user} />

      <UserModal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)} />
    </div>
  );
}
