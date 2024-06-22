import React, { useEffect, useState } from "react";
import DatePicker from "react-datepicker";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-datepicker/dist/react-datepicker.css";
import { Container } from "react-bootstrap";
import { Button, Modal } from "react-bootstrap";
import GetProductsDTO from "../types/GetProductsDTO";
import GetOrdersDTO from "../types/GetOrdersDTO";
import GetTransportsDTO from "../types/GetTransportsDTO";
import AddOrderDTO from "../types/AddOrderDTO";
import { useNavigate } from "react-router-dom";

function AddOrder() {
  const [selectedDateStart, setSelectedDateStart] = useState<Date>();
  const [selectedDatePlannedEnd, setSelectedDatePlannedEnd] = useState<Date>();
  const [showSetPojazd, setShowSetPojazd] = useState(false);
  const [showSetProdukty, setShowSetProdukty] = useState(false);
  const [products, setProducts] = useState<Array<GetProductsDTO>>([]);
  const [transports, setTransports] = useState<Array<GetTransportsDTO>>([]);
  const [adress, setAdress] = useState("");
  const [response, setResponse] = useState(null);
  const [selectedIds, setSelectedIds] = useState<Array<number>>([]);
  const [transportCheckBoxCheckedId, setTransportCheckBoxCheckedId] =
    useState<number>(-1);
  useState<number>();
  const navigate = useNavigate();

  const handleCheckboxProduktyChange = (
    event: React.ChangeEvent<HTMLInputElement>,
    id: number
  ) => {
    const checkedId = id;
    console.log(checkedId);
    if (event.target.checked) {
      setSelectedIds([...selectedIds, checkedId]);
    } else {
      setSelectedIds(selectedIds.filter((id) => id !== checkedId));
    }
  };

  const onChangeTransportCheckbox = (value: number) => {
    console.log(value);
    setTransportCheckBoxCheckedId(value);
  };

  const handleCloseShowSetPojazdAnuluj = () => {
    setShowSetPojazd(false);
  };
  const handleCloseShowSetPojazdZapisz = () => {
    setShowSetPojazd(false);
  };
  const handleShowSetPojazd = () => {
    fetch("https://localhost:7155/Transporter")
      .then((response) => response.json())
      .then((json) => {
        let jsonObject = json as Array<GetTransportsDTO>;
        console.log(jsonObject);
        setTransports(jsonObject);
      })
      .catch((error) => console.log(error));
    setShowSetPojazd(true);
  };

  const handleCloseShowSetProduktyAnuluj = () => setShowSetProdukty(false);
  const handleCloseShowSetProduktyZapisz = () => setShowSetProdukty(false);
  const handleShowSetProdukty = () => {
    fetch("https://localhost:7155/api/Product/GetProductsWithoutOrderId")
      .then((response) => response.json())
      .then((json) => {
        let jsonObject = json as Array<GetProductsDTO>;
        console.log(jsonObject);
        setProducts(jsonObject);
      })
      .catch((error) => console.log(error));
    setShowSetProdukty(true);
  };

  const handleAddOrder = async () => {
    const AddOrderDTO: AddOrderDTO = {
      dataWyruszenia: selectedDateStart ? selectedDateStart : new Date(),
      planowanaDataDostraczenia: selectedDatePlannedEnd
        ? selectedDatePlannedEnd
        : new Date(),
      adresDostawy: adress,
      idTransportu: transportCheckBoxCheckedId,
      idProduktow: selectedIds,
    };
    try {
      const response = await fetch("https://localhost:7155/Order", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(AddOrderDTO),
      });

      if (response.ok) {
        const jsonResponse = await response.json();
        setResponse(jsonResponse);
      } else {
        console.error("Error:", response.statusText);
      }
    } catch (error) {
      console.error("Error:", error);
    }
    navigate("/Orders");
  };

  return (
    <Container>
      <form>
        <div className="container d-flex bd-highlight mb-3">
          <div className="form-group p-2 bd-highlight">
            <label htmlFor="datePicker">Wybierz datę wyruszenia: </label>
            <DatePicker
              id="datePicker"
              selected={selectedDateStart}
              onChange={(date) => setSelectedDateStart(date ? date : undefined)}
              className="form-control"
              dateFormat="dd/MM/yyyy"
            />
          </div>
        </div>

        <div className="container d-flex bd-highlight mb-3">
          <div className="form-group p-2 bd-highlight">
            <label htmlFor="datePicker">
              Wybierz planowana datę dostarczenia:
            </label>
            <DatePicker
              id="datePicker"
              selected={selectedDatePlannedEnd}
              onChange={(date) =>
                setSelectedDatePlannedEnd(date ? date : undefined)
              }
              className="form-control"
              dateFormat="dd/MM/yyyy"
            />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              type="text"
              className="form-control"
              placeholder="Adres dostawy"
              onChange={(e) => setAdress(e.target.value)}
              value={adress}
            />
          </div>
        </div>
      </form>
      <div className="row mt-2">
        <div className="col">
          <button
            type="submit"
            className="btn btn-primary"
            onClick={() => handleShowSetPojazd()}
          >
            {" "}
            Wybierz pojazd
          </button>
        </div>
      </div>
      <div className="row mt-2">
        <div className="col">
          <button
            type="submit"
            className="btn btn-primary"
            onClick={() => handleShowSetProdukty()}
          >
            {" "}
            Wybierz produkty
          </button>
        </div>
      </div>
      <div className="row mt-2">
        <div className="col">
          <button
            type="submit"
            className="btn btn-success"
            onClick={() => handleAddOrder()}
          >
            {" "}
            Dodaj zamowienia
          </button>
        </div>
      </div>
      <Modal
        className="modal-lg"
        show={showSetPojazd}
        onHide={handleCloseShowSetPojazdAnuluj}
      >
        <Modal.Header closeButton>
          <Modal.Title>Pojazdy</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {transports.map((item, index) => (
            <ul className="list-group list-group-horizontal ml-2">
              <li className="list-group-item col-sm-1">{item.id}</li>
              <li className="list-group-item col-sm-3">{item.marka}</li>
              <li className="list-group-item col-sm-3 ">{item.model}</li>
              <li className="list-group-item col-sm-3">
                {item.czyMozeNiebezpieczne ? "tak" : "nie"}
              </li>
              <li className="list-group-item col-sm-1 ">
                <form>
                  <input
                    type="checkbox"
                    value={item.id}
                    checked={transportCheckBoxCheckedId == item.id}
                    onChange={(event) => {
                      onChangeTransportCheckbox(item.id);
                    }}
                  />
                </form>
              </li>
            </ul>
          ))}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseShowSetPojazdZapisz}>
            Anuluj
          </Button>
          <Button variant="primary" onClick={handleCloseShowSetPojazdZapisz}>
            Wybierz pojazd
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal
        show={showSetProdukty}
        onHide={handleCloseShowSetProduktyAnuluj}
        className="modal-lg"
      >
        <Modal.Header closeButton>
          <Modal.Title>Produkty</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {products.map((item, index) => (
            <ul className="list-group list-group-horizontal ml-2">
              <li className="list-group-item col-sm-1">{item.id}</li>
              <li className="list-group-item col-sm-2">{item.nazwa}</li>
              <li className="list-group-item col-sm-2 ">{item.kategoria}</li>
              <li className="list-group-item col-sm-2">
                {item.czyNiebezpieczny ? "tak" : "nie"}
              </li>
              <li className="list-group-item col-sm-3 ">
                <input
                  type="checkbox"
                  value={item.id}
                  checked={selectedIds.includes(item.id)}
                  onChange={(event) => {
                    handleCheckboxProduktyChange(event, item.id);
                  }}
                />
              </li>
            </ul>
          ))}
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={handleCloseShowSetProduktyAnuluj}
          >
            Anuluj
          </Button>
          <Button variant="primary" onClick={handleCloseShowSetProduktyZapisz}>
            Wybierz produkty
          </Button>
        </Modal.Footer>
      </Modal>
    </Container>
  );
}

export default AddOrder;
