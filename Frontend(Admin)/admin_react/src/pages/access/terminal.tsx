import { useEffect } from "react";
import { useTranslation } from "react-i18next";
import { TerminalData } from "../../components/interfaces/component.types";
import TerminalTable from "../../components/cards/access/card_terminal/terminalTable";

const terminal: TerminalData[] = [];

export default function Terminal() {
  const { t } = useTranslation("common");
  useEffect(() => {
    document.title = t("terminal");
  }, []);
  return (
    <div>
      <span className="text-gray-500 font-medium text-xl">{t("terminal")}</span>
      <TerminalTable terminal={terminal} />
    </div>
  );
}
