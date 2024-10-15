import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { Button } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { Link } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";
import { AccountData } from "../../components/interfaces/component.types";
import AccountTable from "../../components/cards/financies/card_accounts/accountTable";
import AccountModal from "../../components/cards/financies/card_accounts/accountModal";

const account: AccountData[] = [];

export default function Accounts() {
  const { t } = useTranslation("common");
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  useEffect(() => {
    document.title = t("accounts");
  }, []);

  return (
    <div className="flex flex-col justify-center">
      <span className="text-gray-500 font-medium text-xl">{t("accounts")}</span>
      <div className="flex justify-between items-center">
        <Button
          onClick={() => setIsModalOpen(true)}
          variant="contained"
          sx={{
            backgroundColor: "rgb(242, 244, 248)",
            color: "black",
            marginTop: "1rem",
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
          to="/finances/accounts/create"
          variant="contained"
          sx={{
            color: "white",
            textTransform: "none",
            width: "110px",
            marginTop: "1rem",
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

      <AccountTable account={account} />

      <AccountModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
      />
    </div>
  );
}
