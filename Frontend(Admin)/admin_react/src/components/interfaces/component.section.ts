import { ElementType } from "react";
import Statistics from "../../navbar/statistics";
import Sale from "../../navbar/sale";
import Finances from "../../navbar/finances";
import Menu from "../../navbar/menu";
import Marketing from "../../navbar/marketing";
import Staff from "../../navbar/staff";
import Access from "../../navbar/access";
import Settings from "../../navbar/settings";

export interface Section {
  component: ElementType;
  key: string;
}

export const sections: Section[] = [
  { component: Statistics, key: "statistics" },
  { component: Sale, key: "sale" },
  { component: Finances, key: "finances" },
  { component: Menu, key: "menu" },
  { component: Marketing, key: "marketing" },
  { component: Staff, key: "staff" },
  { component: Access, key: "access" },
  { component: Settings, key: "settings" },
];
