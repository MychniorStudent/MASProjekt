import { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { loginContext } from "../App";
function Login() {
  const { setUserNameContext, setUserPasswordContext } =
    useContext(loginContext);
  const [loginValue, setLoginValue] = useState("");
  const [passwordValue, setPasswordValue] = useState("");

  const navigate = useNavigate();
  function loginCall() {
    setUserNameContext(loginValue);
    setUserPasswordContext(passwordValue);
    navigate("/Orders");
  }

  return (
    <form>
      <div className="form-group mt-4">
        <label>Wpisz login</label>
        <input
          type="login"
          className="form-control "
          placeholder="Login"
          onChange={(e) => setLoginValue(e.target.value)}
          value={loginValue}
        />
      </div>
      <div className="form-group mt-4">
        <label>Wpisz hasło</label>
        <input
          type="password"
          className="form-control"
          placeholder="Haslo"
          onChange={(e) => setPasswordValue(e.target.value)}
          value={passwordValue}
        />
      </div>
      <div></div>
      <button
        type="submit"
        className="btn btn-primary mt-4"
        onClick={loginCall}
      >
        Zaloguj
      </button>
    </form>
  );
}

export default Login;
