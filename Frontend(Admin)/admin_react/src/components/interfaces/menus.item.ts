export interface MenusItem {
  to: string;
  label: string;
}

export const menusItem: MenusItem[] = [
  { to: "/menu/products", label: "products" },
  { to: "/menu/categories", label: "categories" },
  { to: "/menu/menuRearrangement", label: "menuRearrangement" },
];
