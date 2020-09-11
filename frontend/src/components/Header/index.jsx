import React, {Component} from 'react';
import separator from './separator.png';
import './styles.css';

export class Header extends Component{

    constructor(props){
        super(props);

        this.state = {
            championshipHasStarted: false
        };
    }

    render(){

        let pageTitle = '';
        let informationText = '';
    
        if(!this.props.championshipHasStarted){
            pageTitle = 'Fase de Seleção';
            informationText = 'Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir'; 
        } else {
            pageTitle = 'Resultado Final';
            informationText = 'Veja o resultado final do Campeonato de filmes de forma simples e rápida'; 
        }

        return (
            <div id="container">
    
                <h3>CAMPEONATO DE FILMES</h3>
                
                <h1 id="current-screen-title">{pageTitle}</h1>
    
                <img src={separator} alt="separator" className="separator"/>
    
                <div id="information-text">
                    {informationText}
                </div>
            </div>
        );
    }
}