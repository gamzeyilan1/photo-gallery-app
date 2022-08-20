import React, {useEffect} from 'react';
import '../styles/Home.module.css'
import Gallery from './components/gallery';


export default function Home() {

    /* this section holds the general structure and calls the gallery class */
    let url = "https://www.linkedin.com/in/gamzeyilan";
    useEffect(() => {
        document.title = "TechGuilds Gallery App"
    }, []);
    return (
        <div>
            <div className={"header"}>
                <div className={"header"}>
                    <h1 style={{textAlign: 'center'}}> TechGuilds Gallery App </h1>
                </div>
            </div>
            <h3 style={{textAlign: 'center'}}> Contact me on <a href={url} style={{color: 'blue'}}> linkedin </a></h3>
            <Gallery/>
        </div>
    );
}
