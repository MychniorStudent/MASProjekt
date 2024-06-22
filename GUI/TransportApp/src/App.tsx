import { Container } from "react-bootstrap";
import Login from "./components/Login";
import Topnavbar from "./components/Topnavbar";
import { createContext, useState } from "react";
import Orders from "./components/Orders";
import AddOrder from "./components/AddOrder";
import AddProduct from "./components/AddProduct";
import AddTransport from "./components/AddTransport";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Products from "./components/Products";

type LogiContextValues = {
  userName: string;
  setUserNameContext: (uname: string) => void;
  userPassword: string;
  setUserPasswordContext: (uname: string) => void;
};

export const loginStorageKey = "login";
export const passwordStorageKey = "password";

export const loginContext = createContext<LogiContextValues>(null as any);

function App() {
  const [userName, setUserName] = useState(
    sessionStorage.getItem(loginStorageKey) ?? ""
  );
  const [userPassword, setUserPassword] = useState(
    sessionStorage.getItem(passwordStorageKey) ?? ""
  );
  return (
    <loginContext.Provider
      value={{
        userName,
        setUserNameContext: (frajerskaNazwa: string) => {
          setUserName(frajerskaNazwa);
          sessionStorage.setItem(loginStorageKey, userName);
        },
        userPassword,
        setUserPasswordContext: (frajerskaNazwa: string) => {
          setUserPassword(frajerskaNazwa);
          sessionStorage.setItem(passwordStorageKey, userPassword);
        },
      }}
    >
      <Container>
        <Router>
          <Topnavbar />
          <Routes>
            <Route path="/login" index element={<Login />} />
            <Route path="/addOrder" element={<AddOrder />} />
            <Route path="/addProduct" element={<AddProduct />} />
            <Route path="/addTransport" element={<AddTransport />} />
            <Route path="/orders" element={<Orders />} />
            <Route path="/products" element={<Products />} />
          </Routes>
        </Router>
      </Container>
    </loginContext.Provider>
  );
}

export default App;
