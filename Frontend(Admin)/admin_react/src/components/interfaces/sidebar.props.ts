export interface SidebarProps {
  openSection: string | null;
  toggleSection: (sectionKey: string) => void;
}
