import { useEffect, useState } from "react";
import { Button, Modal } from "react-bootstrap";
import GetOrdersDTO from "../types/GetOrdersDTO";
import GetProductsDTO from "../types/GetProductsDTO";
import { Container } from "react-bootstrap";

function Orders() {
  const [data, setData] = useState<Array<GetOrdersDTO>>([]);
  const [show, setShow] = useState(false);
  const [products, setProducts] = useState<Array<GetProductsDTO>>([]);

  const handleClose = () => setShow(false);
  const handleShow = (id: number) => {
    fetch(
      "https://localhost:7155/api/Product/GetProductForOrderById?orderId=" + id
    )
      .then((response) => response.json())
      .then((json) => {
        let jsonObject = json as Array<GetProductsDTO>;
        console.log(jsonObject);
        setProducts(jsonObject);
      })
      .catch((error) => console.log(error));
    setShow(true);
  };

  useEffect(() => {
    fetch("https://localhost:7155/Order")
      .then((response) => response.json())
      .then((json) => {
        let jsonObject = json as Array<GetOrdersDTO>;
        console.log(jsonObject);
        setData(jsonObject);
      })
      .catch((error) => console.log(error));
  });

  return (
    <Container>
      <ul className="list-group list-group-horizontal ml-2 d-flex justify-content-center">
        <li className="list-group-item col-sm-1">ID</li>
        <li className="list-group-item col-sm-2">Nazwisko pracownika</li>
        <li className="list-group-item col-sm-2 ">Status</li>
        <li className="list-group-item col-sm-2">Data wyruszenia</li>
        <li className="list-group-item col-sm-2">
          Planowana data dostarczenia
        </li>
        <li className="list-group-item col-sm-2">Data dostarczenia</li>
        <li className="list-group-item col-sm-2">Adres dostawy</li>
        <li className="list-group-item col-sm-2 ">Produkty</li>
      </ul>
      {data.map((item, index) => (
        <ul className="list-group list-group-horizontal d-flex justify-content-center">
          <li className="list-group-item col-sm-1">{item.id}</li>
          <li className="list-group-item col-sm-2">{item.nazwisko}</li>
          <li className="list-group-item col-sm-2 ">{item.status}</li>
          <li className="list-group-item col-sm-2">
            {item.dataWyruszenia.toString()}
          </li>
          <li className="list-group-item col-sm-2">
            {item.planowanaDataDostarczenia.toString()}
          </li>
          <li className="list-group-item col-sm-2">
            {item.dataDostarczenia !== undefined
              ? item.dataDostarczenia?.toString()
              : ""}
          </li>
          <li className="list-group-item col-sm-2">{item.adres}</li>
          <li className="list-group-item col-sm-2">
            <button
              type="submit"
              className="btn btn-primary"
              onClick={() => handleShow(item.id)}
            >
              {" "}
              Pokaż Produkty
            </button>
          </li>
        </ul>
      ))}
      <Modal show={show} onHide={handleClose} className="modal-lg">
        <Modal.Header closeButton>
          <Modal.Title>Produkty</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <ul className="list-group list-group-horizontal ml-2">
            <li className="list-group-item col-sm-1">id</li>
            <li className="list-group-item col-sm-2">nazwa</li>
            <li className="list-group-item col-sm-2 ">kategoria</li>
            <li className="list-group-item col-sm-2">niebezpieczny</li>
            <li className="list-group-item col-sm-2 ">ilosc</li>
          </ul>
          {products.map((item, index) => (
            <ul className="list-group list-group-horizontal ml-2">
              <li className="list-group-item col-sm-1">{item.id}</li>
              <li className="list-group-item col-sm-2">{item.nazwa}</li>
              <li className="list-group-item col-sm-2 ">{item.kategoria}</li>
              <li className="list-group-item col-sm-2">
                {item.czyNiebezpieczny ? "tak" : "nie"}
              </li>
              <li className="list-group-item col-sm-2 ">{item.ilosc}</li>
            </ul>
          ))}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default Orders;
