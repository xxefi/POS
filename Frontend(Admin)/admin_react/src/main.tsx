import { createRoot } from "react-dom/client";
import "./index.css";
import "../i18n.ts";
import {
  ThemeProvider as MUIThemeProvider,
  createTheme,
} from "@mui/material/styles";
import { BrowserRouter } from "react-router-dom";
import AppRoutes from "./routes/appRoutes.tsx";

const muiTheme = createTheme({});

createRoot(document.getElementById("root")!).render(
  <BrowserRouter>
    <MUIThemeProvider theme={muiTheme}>
      <AppRoutes />
    </MUIThemeProvider>
  </BrowserRouter>
);
