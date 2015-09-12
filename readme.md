# GVim Inside

This sample project was created to depict GVim bug
when it is started with `--windowid` switch.

For example, your parent window handle is 0x50830

![GVim container before](http://i.imgur.com/oE5el2R.png)

and when you start gvim as following

    gvim --windowid 0x50830

it must run inside your parent window covering
its whole client area. But in fact, on Windows,
when your run it in such manner you'll get weird
gray gaps around gvim editing area...

![GVim container after](http://i.imgur.com/C4ZW190.png)

But when you resize the container window,
dragging window frame with mouse,
you'll see that gvim adapts to client area...
With some integral steps however.
