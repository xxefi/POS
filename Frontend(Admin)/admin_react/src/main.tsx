import { createRoot } from "react-dom/client";
import "./index.css";
import "rsuite/dist/rsuite.min.css";
import "../i18n.ts";
import {
  ThemeProvider as MUIThemeProvider,
  createTheme,
} from "@mui/material/styles";
import { BrowserRouter } from "react-router-dom";
import AppRoutes from "./routes/appRoutes.tsx";
import { Provider } from "react-redux";
import { store } from "./redux/store.ts";

const muiTheme = createTheme({});

createRoot(document.getElementById("root")!).render(
  <Provider store={store}>
    <BrowserRouter>
      <MUIThemeProvider theme={muiTheme}>
        <AppRoutes />
      </MUIThemeProvider>
    </BrowserRouter>
  </Provider>
);
