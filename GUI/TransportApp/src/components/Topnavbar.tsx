import { useContext, useEffect, useReducer } from "react";
import { Link } from "react-router-dom";
import { loginContext } from "../App";

function Topnavbar() {
  const { userName, userPassword, setUserNameContext, setUserPasswordContext } =
    useContext(loginContext);
  //const [, forceUpdate] = useReducer((x) => x + 1, 0);
  const logout = () => {
    setUserNameContext("");
    setUserPasswordContext("");
    //forceUpdate();
  };
  useEffect(() => {});

  if (userName !== "") {
    return (
      <>
        <ul className="nav border-bottom border-info border-5">
          <li className="nav-item m-1">
            <h1>{"Witaj " + userName}</h1>
          </li>
          <li className="nav-item m-1 mt-2">
            <Link to="/orders">
              <button type="submit" className="btn btn-primary">
                {" "}
                Wyswietl zamowienia
              </button>
            </Link>
          </li>
          <li className="nav-item m-1 mt-2">
            <Link to="/products">
              <button type="submit" className="btn btn-primary">
                {" "}
                Wyswietl produkty
              </button>
            </Link>
          </li>
          <li className="nav-item m-1 mt-2">
            <Link to="/addOrder">
              <button type="submit" className="btn btn-info">
                {" "}
                Dodaj zamowienie
              </button>
            </Link>
          </li>
          <li className="nav-item m-1 mt-2">
            <Link to="/addProduct">
              <button type="submit" className="btn btn-info">
                {" "}
                Dodaj produkt
              </button>
            </Link>
          </li>
          <li className="nav-item m-1 mt-2">
            <Link to="/login">
              <button type="submit" className="btn btn-danger" onClick={logout}>
                {" "}
                Wyloguj ( ͡° ͜ʖ ͡°)
              </button>
            </Link>
          </li>
        </ul>
      </>
    );
  } else {
    return (
      <>
        <h1>TransportApp login</h1>
      </>
    );
  }
}

export default Topnavbar;
