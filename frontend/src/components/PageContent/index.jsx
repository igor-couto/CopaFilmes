import React, {Component} from 'react';
import './style.css';
import {SelectedMoviesCounter} from '../SelectedMoviesCounter';
import { MovieList } from '../MovieList';
import NewChampionshipButton from '../NewChampionshipButton';
import { apiURL } from '../../api/api';

export class PageContent extends Component {

    constructor(props){
        super(props);
    
        this.onCardSelect = this.onCardSelect.bind(this);

        this.state = {
            movies: [],
            selectedMovies: []
        };
    }

    async componentDidMount() {

        const movies = await this.fetchMovies();
        this.setState({
            movies: movies
        });
    }

    async fetchMovies() {
        const response = await fetch(apiURL.movies);
        return await response.json();
    }

    selectMovie(movie){

        const newSelectedMovies = [...this.state.selectedMovies, movie];

        this.setState({
            selectedMovies: newSelectedMovies
        });
    }

    removeMovie(id){
        const newSelectedMovies = [...this.state.selectedMovies];

        this.setState({
            selectedMovies: newSelectedMovies.filter( movie => movie.id !== id)
        });
    }

    onCardSelect(selected, movie){

        if(selected && this.state.selectedMovies.length == 8)
            return false;

        if(selected)
            this.selectMovie(movie)
        else
            this.removeMovie(movie.id)

        return true;
    }

    render(){
        return (
            <div id="page-content">
                <div id="content-info">

                    <SelectedMoviesCounter 
                        selected={this.state.selectedMovies.length} 
                        total="8"
                        winners={this.props.winners}
                    />

                    <NewChampionshipButton
                        selectedMovies={this.state.selectedMovies}
                        onChampionshipStart={this.props.onChampionshipStart}
                    />

                </div>
                
                <MovieList 
                    movies={this.state.movies} 
                    onCardSelect={this.onCardSelect}
                    winners={this.props.winners}
                />
            </div>
        )
    }
}