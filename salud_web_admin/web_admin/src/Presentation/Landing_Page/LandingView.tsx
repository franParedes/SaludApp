import { Button } from "@mui/material"
import { Link } from "react-router-dom"

function Landing_Page() {
  return (
    <div className="bg-[url(assets/images/landing_background.svg)] 
        bg-cover w-full min-h-screen flex justify-center md:justify-start items-center px-10 md:px-24">
        <div className="flex flex-col items-center md:items-left max-w-[35rem] text-white gap-5 text-center md:text-left">
            <h1 className="font-bold text-5xl">Bienvenidos a SaludApp</h1>
            <p className="text-base md:text-lg leading-relaxed">
                Lorem ipsum dolor sit amet consectetur, adipisicing elit. Atque, 
                doloremque ex velit dicta ut aperiam tempora nihil magnam impedit, 
                sequi accusantium vel quod nam. Placeat quod ratione mollitia necessitatibus sed.
            </p>
            <Button 
                variant="outlined"
                component={Link}
                to="/auth/login"
                sx={{ paddingX: 5, paddingY: 1, bgcolor:'primary.main', borderColor: 'white', color: 'white', boxShadow: 3}}
            >
                Empezar
            </Button>
        </div>
    </div>
  )
}

export default Landing_Page
