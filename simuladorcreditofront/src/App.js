import React, { useEffect, useState, useRef } from "react";
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
  const [carregandoSegmento, setCarregandoSegmento] = useState(false);
  const [carregandoTaxa, setCarregandoTaxa] = useState(false);

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

  const debounceTimer = useRef();

  const handleRendaChange = (e) => {
    const valorSomenteNum = e.target.value.replace(/\D/g, "");
    if (valorSomenteNum.length > 12) return;

    const valorFormatado = formatarMoeda(valorSomenteNum);
    setRenda(valorFormatado);

    setMensagensCampos((prev) => ({ ...prev, renda: undefined }));

    clearTimeout(debounceTimer.current);
    debounceTimer.current = setTimeout(() => {
      buscarSegmento(valorSomenteNum);
    }, 600);
  };

  const buscarSegmento = async (valor = null) => {
    const valorNumerico =
      (valor !== null ? Number(valor) : Number(renda.replace(/\D/g, ""))) / 100;

    if (!tipoPessoa || !valorNumerico) {
      setSegmento("");
      return null;
    }

    try {
      setCarregandoSegmento(true);
      const resp = await axios.get(
        `https://localhost:44328/api/v1/Segment/GetSegmentByPersonTypeAsync/${tipoPessoa}/${valorNumerico}`
      );

      const seg =
        typeof resp.data === "string" ? resp.data : Object.keys(resp.data)[0];

      if (!seg) {
        setSegmento("");
        exibirErro("Segmento não identificado.");
        return null;
      }

      setSegmento(seg);
      return seg;
    } catch {
      setSegmento("");
      exibirErro("Erro ao buscar segmento.");
      return null;
    } finally {
      setCarregandoSegmento(false);
    }
  };

  const buscarTaxa = async () => {
    clearTimeout(debounceTimer.current);

    const camposInvalidos = {};
    const valorNumerico = Number(renda.replace(/\D/g, "")) / 100;

    if (!tipoPessoa) camposInvalidos.tipoPessoa = "Selecione o tipo de pessoa.";
    if (!modalidade) camposInvalidos.modalidade = "Selecione uma modalidade.";
    if (!produto) camposInvalidos.produto = "Selecione um produto.";
    if (!valorNumerico || isNaN(valorNumerico) || valorNumerico <= 0)
      camposInvalidos.renda = "Informe uma renda válida.";

    if (Object.keys(camposInvalidos).length) {
      setMensagensCampos(camposInvalidos);
      return;
    }

    setMensagensCampos({});

    const segObtido = await buscarSegmento();
    if (!segObtido) {
      setMensagensCampos({ segmento: "Segmento não calculado ainda." });
      return;
    }

    setCarregandoTaxa(true);
    try {
      const resp = await axios.get(
        `https://localhost:44328/api/v1/Rate/GetRateByAsync/${tipoPessoa}/${modalidade}/${produto}/${segmento}`
      );
      if (!resp.data || typeof resp.data !== "number") throw new Error();
      setTaxa(resp.data);
    } catch {
      exibirErro("Erro ao buscar taxa.");
    } finally {
      setCarregandoTaxa(false);
    }
  };

  const exibirErro = (mensagem) => {
    setErro(mensagem);
    setTimeout(() => setErro(""), 5000);
  };

  const formatarMoeda = (valor) => {
    const inteiro = valor.slice(0, -2) || "0";
    const decimal = valor.slice(-2).padStart(2, "0");
    return new Intl.NumberFormat("pt-BR", {
      style: "currency",
      currency: "BRL",
    }).format(`${parseInt(inteiro, 10)}.${decimal}`);
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

  const camposPreenchidos =
    tipoPessoa &&
    modalidade &&
    produto &&
    renda &&
    Number(renda.replace(/\D/g, "")) > 0;

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
              value={renda}
              onChange={handleRendaChange}
              placeholder="R$ 0,00"
            />
            {mensagensCampos.renda && (
              <p className="mensagem-erro">{mensagensCampos.renda}</p>
            )}
          </div>

          <div className="botoes">
            <button
              className="btn"
              onClick={buscarTaxa}
              disabled={!camposPreenchidos || carregandoTaxa}
            >
              {carregandoTaxa ? "Calculando..." : "Calcular Taxa"}
            </button>
            <button className="btn btn-limpar" onClick={resetarFormulario}>
              Limpar
            </button>
          </div>
        </div>

        <div className="coluna-direita">
          <div className="resultado">
            <h2>Resultado da Simulação</h2>
            {carregandoSegmento && (
              <p className="mensagem-auxiliar">Buscando segmento...</p>
            )}
            {!carregandoSegmento && segmento && (
              <p className="mensagem-auxiliar">
                Segmento: {nomesSegmentos[segmento]}
              </p>
            )}
            {!carregandoSegmento && !segmento && (
              <p className="mensagem-auxiliar">
                Informe uma renda válida para identificar o segmento
              </p>
            )}
            {renda && (
              <p className="mensagem-auxiliar">Renda informada: {renda}</p>
            )}
            <p className="mensagem-auxiliar">
              {taxa !== null
                ? `Taxa encontrada: ${taxa.toFixed(2)}%`
                : "Preencha todos os campos obrigatórios e clique em 'Calcular Taxa'"}
            </p>
          </div>
          <p className="nota">
            * Campos obrigatórios
            <br />A taxa é calculada com base no segmento, modalidade e produto
            selecionados.
          </p>
        </div>
      </div>
    </div>
  );
}
