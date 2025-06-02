import React, { useEffect, useState } from "react";
import axios from "axios";

import "./App.css";

export default function Simulador() {
  const [tipoPessoa, setTipoPessoa] = useState("");
  const [tiposPessoa, setTiposPessoa] = useState([]);
  const [modalidade, setModalidade] = useState("");
  const [produto, setProduto] = useState("");
  const [segmento, setSegmento] = useState("");
  const [renda, setRenda] = useState("");
  const [produtos, setProdutos] = useState([]);
  const [modalidades, setModalidades] = useState([]);
  const [taxa, setTaxa] = useState(null);
  const [erro, setErro] = useState("");
  const [mensagensCampos, setMensagensCampos] = useState({});
  const [carregando, setCarregando] = useState(false);

  const nomesSegmentos = {
    PF1: "Pessoa Física - Nível 1",
    PF2: "Pessoa Física - Nível 2",
    PF3: "Pessoa Física - Nível 3",
    PF4: "Pessoa Física - Nível 4",
    PJ1: "Pessoa Jurídica - Nível 1",
    PJ2: "Pessoa Jurídica - Nível 2",
    PJ3: "Pessoa Jurídica - Nível 3",
    PJ4: "Pessoa Jurídica - Nível 4",
  };

  useEffect(() => {
    axios
      .get("https://localhost:44328/api/v1/Modality")
      .then((res) => setModalidades(res.data))
      .catch(() => exibirErro("Erro ao carregar modalidades."));

    axios
      .get("https://localhost:44328/api/v1/PersonType")
      .then((res) => setTiposPessoa(res.data))
      .catch(() => exibirErro("Erro ao carregar tipos de pessoa."));
  }, []);

  useEffect(() => {
    if (tipoPessoa) {
      axios
        .get(
          `https://localhost:44328/api/v1/Product/GetByPersonType/${tipoPessoa}`
        )
        .then((res) => {
          if (!Array.isArray(res.data)) throw new Error();
          setProdutos(res.data);
          setProduto(res.data[0] || "");
        })
        .catch(() => exibirErro("Erro ao carregar produtos."));
    } else {
      setProdutos([]);
      setProduto("");
    }
  }, [tipoPessoa]);

  useEffect(() => {
    const valorNumerico = Number(renda.replace(/\D/g, "")) / 100;
    if (tipoPessoa && valorNumerico > 0) {
      axios
        .get(
          `https://localhost:44328/api/v1/Segment/GetSegmentByPersonTypeAsync/${tipoPessoa}/${valorNumerico}`
        )
        .then((res) => {
          if (!res.data || !res.data.segmento) {
            setSegmento("");
            exibirErro(
              "Não foi possível determinar o segmento com base na renda informada."
            );
            return;
          }
          setSegmento(res.data.segmento);
        })
        .catch(() => {
          setSegmento("");
          exibirErro("Erro ao buscar segmento.");
        });
    } else {
      setSegmento("");
    }
  }, [tipoPessoa, renda]);

  const buscarTaxa = () => {
    const camposInvalidos = {};
    const valorNumerico = Number(renda.replace(/\D/g, "")) / 100;

    if (!tipoPessoa) camposInvalidos.tipoPessoa = "Selecione o tipo de pessoa.";
    if (!modalidade) camposInvalidos.modalidade = "Selecione uma modalidade.";
    if (!produto) camposInvalidos.produto = "Selecione um produto.";
    if (!valorNumerico || isNaN(valorNumerico) || valorNumerico <= 0)
      camposInvalidos.renda = "Informe uma renda válida.";

    if (Object.keys(camposInvalidos).length > 0) {
      setMensagensCampos(camposInvalidos);
      return;
    }

    setMensagensCampos({});
    setCarregando(true);

    axios
      .get(
        `https://localhost:44328/api/v1/Rate/GetRateByAsync/${tipoPessoa}/${modalidade}/${produto}/${segmento}`
      )
      .then((res) => {
        if (!res.data || typeof res.data.taxa !== "number")
          throw new Error("Resposta inválida da API");
        setTaxa(res.data.taxa);
      })
      .catch(() => exibirErro("Erro ao buscar taxa."))
      .finally(() => setCarregando(false));
  };

  const exibirErro = (mensagem) => {
    setErro(mensagem);
    setTimeout(() => setErro(""), 5000);
  };

  const apenasNumeros = (valor) => valor.replace(/\D/g, "");

  const formatarMoeda = (valor) => {
    const inteiro = valor.slice(0, -2) || "0";
    const decimal = valor.slice(-2).padStart(2, "0");
    const comPonto = `${parseInt(inteiro, 10)}.${decimal}`;
    return new Intl.NumberFormat("pt-BR", {
      style: "currency",
      currency: "BRL",
    }).format(comPonto);
  };

  const handleRendaChange = (e) => {
    const valor = apenasNumeros(e.target.value);
    if (valor.length <= 12) {
      setRenda(formatarMoeda(valor));
    }
  };

  const resetarFormulario = () => {
    setTipoPessoa("");
    setModalidade("");
    setProduto("");
    setSegmento("");
    setRenda("");
    setProdutos([]);
    setTaxa(null);
    setErro("");
    setMensagensCampos({});
  };

  return (
    <div className="container">
      <h1>Simulador de Taxa</h1>
      {erro && <div className="erro">{erro}</div>}

      <div className="formulario">
        <div className="coluna-esquerda">
          <div className="campo">
            <label>Tipo de Pessoa *</label>
            <select
              value={tipoPessoa}
              onChange={(e) => setTipoPessoa(e.target.value)}
            >
              <option value="">Selecione o tipo de pessoa</option>
              {tiposPessoa.map((tp) => (
                <option key={tp} value={tp}>
                  {tp}
                </option>
              ))}
            </select>
            {mensagensCampos.tipoPessoa && (
              <p className="mensagem-erro">{mensagensCampos.tipoPessoa}</p>
            )}
          </div>

          <div className="campo">
            <label>Modalidade *</label>
            <select
              value={modalidade}
              onChange={(e) => setModalidade(e.target.value)}
            >
              <option value="">Selecione uma modalidade</option>
              {modalidades.map((m) => (
                <option key={m} value={m}>
                  {m}
                </option>
              ))}
            </select>
            {mensagensCampos.modalidade && (
              <p className="mensagem-erro">{mensagensCampos.modalidade}</p>
            )}
          </div>

          <div className="campo">
            <label>Produto *</label>
            <select
              value={produto}
              onChange={(e) => setProduto(e.target.value)}
              disabled={!tipoPessoa}
            >
              <option value="">
                {tipoPessoa
                  ? "Selecione um produto"
                  : "Primeiro selecione o tipo de pessoa"}
              </option>
              {produtos.map((p) => (
                <option key={p} value={p}>
                  {p}
                </option>
              ))}
            </select>
            {mensagensCampos.produto && (
              <p className="mensagem-erro">{mensagensCampos.produto}</p>
            )}
          </div>

          <div className="campo">
            <label>Renda Faturamento Mensal *</label>
            <input
              type="text"
              placeholder="R$ 0,00"
              value={renda}
              onChange={handleRendaChange}
            />
            {mensagensCampos.renda && (
              <p className="mensagem-erro">{mensagensCampos.renda}</p>
            )}
          </div>

          <div className="botoes">
            <button onClick={buscarTaxa} disabled={carregando} className="btn">
              {carregando ? "Calculando..." : "Calcular Taxa"}
            </button>
            <button onClick={resetarFormulario} className="btn btn-limpar">
              Limpar
            </button>
          </div>
        </div>

        <div className="coluna-direita">
          <div className="resultado">
            <h2>Resultado da Simulação</h2>
            {segmento ? (
              <p>
                <strong>Segmento:</strong>{" "}
                {nomesSegmentos[segmento] || segmento}
              </p>
            ) : (
              <p className="mensagem-auxiliar">
                Informe uma renda válida para identificar o segmento
              </p>
            )}
            {taxa !== null ? (
              <p>
                <strong>Taxa:</strong> {taxa.toFixed(2)}%
              </p>
            ) : (
              <p className="mensagem-auxiliar">
                Preencha todos os campos obrigatórios e clique em 'Calcular
                Taxa'
              </p>
            )}
          </div>
        </div>
      </div>

      <p className="nota">* Campos obrigatórios</p>
      <p className="nota">
        A taxa é calculada com base no segmento, modalidade e produto
        selecionados.
      </p>
    </div>
  );
}
