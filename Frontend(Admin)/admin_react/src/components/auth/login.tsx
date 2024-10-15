import { CircularProgress, TextField } from "@mui/material";
import { ChangeEvent, useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import { LoginState } from "../interfaces/login.state";
import DateLang from "./dateLang";

export default function Login() {
  const [state, setState] = useState<LoginState>({
    brand: "",
    loading: false,
    email: "",
    password: "",
    error: "",
    isAuthenticated: false,
    currentDateTime: "string",
  });
  const { t } = useTranslation("common");
  const navigate = useNavigate();

  useEffect(() => {
    const updateDataTime = () => {
      const now = new Date();
      setState((prevState) => ({
        ...prevState,
        currentDateTime: now.toLocaleString(),
      }));
    };
    updateDataTime();
    const intervalId = setInterval(updateDataTime, 1000);
    return () => clearInterval(intervalId);
  }, []);

  const handleCheckBrand = () => {
    setState((prevState) => ({
      ...prevState,
      loading: true,
      error: "",
    }));
    setTimeout(() => {
      setState((prevState) => ({
        ...prevState,
        loading: false,
      }));
    }, 1000);
  };

  const handleLogin = () => {
    setState((prevState) => ({
      ...prevState,
      isAuthenticated: true,
    }));
    navigate(`/${state.brand}/`);
  };

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { id, value } = e.target;
    setState((prevState) => ({
      ...prevState,
      [id]: value,
    }));
  };

  const currentLanguage = t("currentLanguage");

  return (
    <div>
      <div className="flex items-center justify-center min-h-screen bg-gradient-to-br from-gray-100 to-blue-200">
        <DateLang
          currentDateTime={state.currentDateTime}
          currentLanguage={currentLanguage}
        />
        <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
          <h1 className="text-2xl font-bold text-center mb-6">
            {t("brandLogin")}
          </h1>
          <form>
            <div className="mb-4">
              <label htmlFor="brand" className="block text-gray-700">
                {t("brandName")}
              </label>
              <input
                type="text"
                id="brand"
                value={state.brand}
                onChange={handleChange}
                placeholder={t("enterYourBrand")}
                className="mt-2 w-full p-3 border border-gray-300 rounded-lg focus:outline-none focus:border-blue-400"
              />
            </div>
            {state.error && (
              <div className="mb-4 text-red-500 text-center">{state.error}</div>
            )}
            <div className="flex justify-center">
              <button
                type="button"
                onClick={handleCheckBrand}
                disabled={state.loading}
                className={`w-full mt-4 p-3 rounded-lg text-white ${
                  state.loading ? "bg-gray-400" : "bg-black hover:bg-black"
                } focus:outline-none focus:ring-2 focus:ring-black focus:ring-opacity-50`}
              >
                {state.loading ? (
                  <div className="flex items-center justify-center">
                    <CircularProgress
                      size={24}
                      color="inherit"
                      className="mr-2"
                    />
                  </div>
                ) : (
                  t("checkBrand")
                )}
              </button>
            </div>
            {state.isAuthenticated && (
              <>
                <div className="mb-4">
                  <label htmlFor="email" className="block text-gray-700">
                    {t("email")}
                  </label>
                  <TextField
                    type="email"
                    id="email"
                    value={state.email}
                    onChange={handleChange}
                    placeholder={t("enterYourEmail")}
                    className="mt-2 w-full"
                    variant="outlined"
                    fullWidth
                    required
                  />
                </div>

                <div className="mb-4">
                  <label htmlFor="password" className="block text-gray-700">
                    {t("password")}
                  </label>
                  <TextField
                    type="password"
                    id="password"
                    value={state.password}
                    onChange={handleChange}
                    placeholder={t("enterYourPassword")}
                    className="mt-2 w-full"
                    variant="outlined"
                    fullWidth
                    required
                  />
                </div>
                <div className="flex justify-center">
                  <button
                    type="button"
                    onClick={handleLogin}
                    className={`w-full mt-4 p-3 rounded-lg text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50`}
                  >
                    {t("login")}
                  </button>
                </div>
              </>
            )}
          </form>
        </div>
      </div>
    </div>
  );
}
