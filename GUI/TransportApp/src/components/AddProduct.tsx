import { useState } from "react";
import AddProductDTO from "../types/AddProductDTO";

function AddProduct() {
  const [productName, setProductName] = useState("");
  const [productCategory, setProductCategory] = useState("");
  const [productAmount, setProductAmount] = useState(0);
  const [isDangerous, setIsDangerous] = useState(false);
  const [response, setResponse] = useState(null);

  const addProductBtnClick = async () => {
    const AddProductDTO: AddProductDTO = {
      nazwa: productName,
      kategoria: productCategory,
      ilosc: productAmount,
      czyNiebezpieczny: isDangerous,
    };
    try {
      const response = await fetch(
        "https://localhost:7155/api/Product/AddProduct",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(AddProductDTO),
        }
      );

      if (response.ok) {
        const jsonResponse = await response.json();
        setResponse(jsonResponse);
      } else {
        console.error("Error:", response.statusText);
      }
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <>
      <form>
        <div className="row mt-2">
          <div className="col">
            <input
              type="text"
              className="form-control"
              placeholder="Nazwa produktu"
              onChange={(e) => setProductName(e.target.value)}
              value={productName}
            />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              type="text"
              className="form-control"
              placeholder="Kategoria produktu"
              onChange={(e) => setProductCategory(e.target.value)}
              value={productCategory}
            />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              type="number"
              className="form-control"
              placeholder="Ilosc"
              onChange={(e) => setProductAmount(e.target.valueAsNumber)}
              value={productAmount}
            />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              className="form-check-input"
              type="checkbox"
              value=""
              id="flexCheckDefault"
              onChange={(e) => setIsDangerous(e.target.checked)}
            />
            <label className="form-check-label" htmlFor="flexCheckDefault">
              Czy produkt jest niebezpieczny?
            </label>
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <button
              type="submit"
              className="btn btn-success"
              onClick={addProductBtnClick}
            >
              {" "}
              Dodaj produkt
            </button>
          </div>
        </div>
      </form>
    </>
  );
}

export default AddProduct;
