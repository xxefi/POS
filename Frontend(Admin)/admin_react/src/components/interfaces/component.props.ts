export interface ComponentProps {
  t: (key: string) => string;
  setOpen: (open: boolean) => void;
  open: boolean;
}
